    int lineCount = tvResult.LineCount;
    SpannableString spannableText =new SpannableString(tvResult.Text);
    for (int i = 0; i < lineCount; i++)
    {
       int start=tvResult.Layout.GetLineStart(i);
       int end = tvResult.Layout.GetLineEnd(i);
       if (i % 2 == 1)
       {
           spannableText.SetSpan(new ForegroundColorSpan(Android.Graphics.Color.Yellow), start, end, SpanTypes.Composing);
       }
       else
       {
           spannableText.SetSpan(new ForegroundColorSpan(Android.Graphics.Color.Green), start, end,SpanTypes.Composing);
       }
    }
    tvResult.TextFormatted = spannableText;
