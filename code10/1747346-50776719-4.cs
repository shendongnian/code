	var sushiFont = Typeface.CreateFromAsset(Assets, "Tastysushi.ttf");
	var spannableString = new SpannableStringBuilder("123");
	var spannable = new SpannableString(" = SushiHangover");
	spannableString.Append(spannable, new CustomTypefaceSpan(sushiFont), SpanTypes.ExclusiveInclusive);
	button.SetText(spannableString, TextView.BufferType.Spannable);
