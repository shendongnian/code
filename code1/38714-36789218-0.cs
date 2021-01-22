    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    namespace Hillinworks.Wpf.Utilities.Behaviors
    {
        enum EllipsisPosition
        {
            Start,
            Middle,
            End
        }
        static class TextBlockTrimming
        {
            private class BehaviorData
            {
                public EllipsisPosition EllipsisPosition;
                public string OriginalText;
            }
            private class TextChangedEventScreener : IDisposable
            {
                private readonly TextBlock _textBlock;
                public TextChangedEventScreener(TextBlock textBlock)
                {
                    _textBlock = textBlock;
                    s_textPropertyDescriptor.RemoveValueChanged(textBlock, TextBlockTrimming.TextBlock_TextChanged);
                }
                public void Dispose()
                {
                    s_textPropertyDescriptor.AddValueChanged(_textBlock, TextBlockTrimming.TextBlock_TextChanged);
                }
            }
            private static readonly Dictionary<TextBlock, BehaviorData> s_storage =
                new Dictionary<TextBlock, BehaviorData>();
            private static readonly DependencyPropertyDescriptor s_textPropertyDescriptor =
                DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
            private const string ELLIPSIS = "...";
            private static readonly Size s_inifinitySize = new Size(double.PositiveInfinity, double.PositiveInfinity);
            public static EllipsisPosition GetEllipsisPosition(TextBlock obj)
            {
                return (EllipsisPosition)obj.GetValue(EllipsisPositionProperty);
            }
            public static void SetEllipsisPosition(TextBlock obj, EllipsisPosition value)
            {
                obj.SetValue(EllipsisPositionProperty, value);
            }
            public static readonly DependencyProperty EllipsisPositionProperty =
                DependencyProperty.RegisterAttached("EllipsisPosition",
                                                    typeof(EllipsisPosition),
                                                    typeof(TextBlockTrimming),
                                                    new PropertyMetadata(EllipsisPosition.End,
                                                                         TextBlockTrimming.OnEllipsisPositionChanged));
            private static void OnEllipsisPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var textBlock = d as TextBlock;
                if (textBlock == null)
                    return;
                var ellipsisPosition = (EllipsisPosition)e.NewValue;
                TextBlockTrimming.OnEllipsisPositionChanged(textBlock, ellipsisPosition);
            }
            private static BehaviorData GetData(TextBlock textBlock)
            {
                BehaviorData data;
                if (s_storage.TryGetValue(textBlock, out data))
                    return data;
                s_storage[textBlock] = data = new BehaviorData();
                s_textPropertyDescriptor.AddValueChanged(textBlock, TextBlockTrimming.TextBlock_TextChanged);
                textBlock.SizeChanged += TextBlockTrimming.TextBlock_SizeChanged;
                data.OriginalText = textBlock.Text;
                return data;
            }
            private static void TextBlock_TextChanged(object sender, EventArgs e)
            {
                var textBlock = (TextBlock)sender;
                var data = TextBlockTrimming.GetData(textBlock);
                data.OriginalText = textBlock.Text;
                TextBlockTrimming.TrimText(textBlock);
            }
            private static void TextBlock_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                TextBlockTrimming.TrimText((TextBlock)sender);
            }
            private static void OnEllipsisPositionChanged(TextBlock textBlock, EllipsisPosition ellipsisPosition)
            {
                var data = TextBlockTrimming.GetData(textBlock);
                data.EllipsisPosition = ellipsisPosition;
                TextBlockTrimming.TrimText(textBlock);
            }
            private static double MeasureString(this TextBlock textBlock, string text)
            {
                textBlock.Text = text;
                textBlock.Measure(s_inifinitySize);
                return textBlock.DesiredSize.Width;
            }
            private static IDisposable BlockTextChangedEvent(TextBlock textBlock)
            {
                return new TextChangedEventScreener(textBlock);
            }
            private static void TrimText(TextBlock textBlock)
            {
                if (DesignerProperties.GetIsInDesignMode(textBlock))
                    return;
                if (textBlock.TextTrimming != TextTrimming.CharacterEllipsis || textBlock.TextWrapping != TextWrapping.NoWrap)
                    return;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (textBlock.ActualWidth == 0)
                    return;
                using (TextBlockTrimming.BlockTextChangedEvent(textBlock))
                {
                    var data = TextBlockTrimming.GetData(textBlock);
                    // this actually sets textBlock's text back to its original value
                    var desiredSize = textBlock.MeasureString(data.OriginalText);
                    if (desiredSize <= textBlock.ActualWidth)
                        return;
                    var ellipsisSize = textBlock.MeasureString(ELLIPSIS);
                    var freeSize = textBlock.ActualWidth - ellipsisSize;
                    var segments = new List<string>();
                    var epsilon = ellipsisSize / 3;
                    var builder = new StringBuilder();
                    var text = data.OriginalText;
                    switch (data.EllipsisPosition)
                    {
                        case EllipsisPosition.End:
                            TextBlockTrimming.TrimText(textBlock, text, freeSize, segments, epsilon, false);
                            foreach (var segment in segments)
                                builder.Append(segment);
                            builder.Append(ELLIPSIS);
                            break;
                        case EllipsisPosition.Start:
                            TextBlockTrimming.TrimText(textBlock, text, freeSize, segments, epsilon, true);
                            builder.Append(ELLIPSIS);
                            foreach (var segment in ((IEnumerable<string>)segments).Reverse())
                                builder.Append(segment);
                            break;
                        case EllipsisPosition.Middle:
                            var textLength = text.Length / 2;
                            var firstHalf = text.Substring(0, textLength);
                            var secondHalf = text.Substring(textLength);
                            freeSize /= 2;
                            TextBlockTrimming.TrimText(textBlock, firstHalf, freeSize, segments, epsilon, false);
                            foreach (var segment in segments)
                                builder.Append(segment);
                            builder.Append(ELLIPSIS);
                            segments.Clear();
                            TextBlockTrimming.TrimText(textBlock, secondHalf, freeSize, segments, epsilon, true);
                            foreach (var segment in ((IEnumerable<string>)segments).Reverse())
                                builder.Append(segment);
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                    textBlock.Text = builder.ToString();
                }
            }
            private static void TrimText(TextBlock textBlock, string text, double size, ICollection<string> segments, double epsilon, bool reversed)
            {
                while (true)
                {
                    var halfLength = text.Length / 2;
                    var firstHalf = reversed ? text.Substring(halfLength) : text.Substring(0, halfLength);
                    var remainingSize = size - textBlock.MeasureString(firstHalf);
                    if (remainingSize < 0)
                    {
                        // only one character and it's still too large for the room, skip it
                        if (firstHalf.Length == 1)
                            return;
                        text = firstHalf;
                        continue;
                    }
                    segments.Add(firstHalf);
                    if (remainingSize > epsilon)
                    {
                        var secondHalf = reversed ? text.Substring(0, halfLength) : text.Substring(halfLength);
                        text = secondHalf;
                        size = remainingSize;
                        continue;
                    }
                    break;
                }
            }
        }
    }
