            Button button = FindViewById<Button>(Resource.Id.myButton);
            SpannableStringBuilder spannable = new SpannableStringBuilder("Big Little");
            spannable.SetSpan(new AbsoluteSizeSpan(50), 0, 3, SpanTypes.ExclusiveInclusive);
            spannable.SetSpan(new AbsoluteSizeSpan(25), 4, 10, SpanTypes.ExclusiveInclusive);
            button.SetText(spannable, TextView.BufferType.Editable);
