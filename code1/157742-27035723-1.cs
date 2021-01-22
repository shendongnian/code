    using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Documents;
        
        namespace UI.WPF.UserControls
        {
            class CustomTextBlock:TextBlock
            {
                string _originalText;
        
                public string HighlighText
                {
                    get { return (string)GetValue(HighlighTextProperty); }
                    set
                    {
                        SetValue(HighlighTextProperty, value);
                        
                        RenderHighlightedText();
                    }
                }
        
                // Using a DependencyProperty as the backing store for HighlighText.  This enables animation, styling, binding, etc...
                public static readonly DependencyProperty HighlighTextProperty =
                    DependencyProperty.Register("HighlighText", typeof(string), typeof(CustomTextBlock),
                         new FrameworkPropertyMetadata(new PropertyChangedCallback(HighlighTextProperty_Changed))
                         );
        
                private static void HighlighTextProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {
                    CustomTextBlock textBlock = (CustomTextBlock)d;
                    textBlock.RenderHighlightedText();
                }
        
        
                public CustomTextBlock()
                    : base()
                {
        
                }
        
                static CustomTextBlock()
                {
                    DefaultStyleKeyProperty.OverrideMetadata(
                        typeof(CustomTextBlock),
                        new FrameworkPropertyMetadata(typeof(CustomTextBlock)));
                }
        
                public override void OnApplyTemplate()
                {
        
                    base.OnApplyTemplate();
                }
        
                protected override void OnInitialized(EventArgs e)
                {
                    base.OnInitialized(e);
                    _originalText = Text;
               
                    RenderHighlightedText();
                }
        
        
                private Run GetFormatedText(string text, bool isBold)
                {
                    Run noramlRun = new Run(text);
                    if (isBold)
                    {
                        noramlRun.FontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        noramlRun.FontWeight = FontWeights.Normal;
                    }
        
                    return noramlRun;
                }
                public void RenderHighlightedText()
                {
                    var boldText = HighlighText;
        
                    if (!string.IsNullOrEmpty(HighlighText) &&
                        _originalText.ToLower().Contains(boldText.ToLower()))
                    {
        
                        this.Inlines.Clear();
        
                        int point = _originalText.ToLower().IndexOf(boldText.ToLower());
                        string strHighlighted = _originalText.Substring(point, HighlighText.Length);
        
                        Run runHighlight = GetFormatedText(strHighlighted, true);
        
                        if (point == 0)
                        {
                            this.Inlines.Add(runHighlight);
                            int remainingLength = _originalText.Length - (point + HighlighText.Length);
        
                            string remaingText = _originalText.Substring((point + HighlighText.Length), remainingLength);
                            this.Inlines.Add(GetFormatedText(remaingText, false));
                        }
                        else
                        {
                            string firstPart = _originalText.Substring(0, point);
                            this.Inlines.Add(GetFormatedText(firstPart, false));
                            this.Inlines.Add(runHighlight);
                            int remainingLength = _originalText.Length - (point + HighlighText.Length);
                            string remaingText = _originalText.Substring((point + HighlighText.Length), remainingLength);
                            this.Inlines.Add(GetFormatedText(remaingText, false));
        
                        }
        
                    }
                    else
                    {
        
                        this.Inlines.Clear();
        
        
                        this.Inlines.Add(GetFormatedText(_originalText, false));
                    }
        
                }
            }
        }
