    // var param = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
    //ViewGroup.LayoutParams.WrapContent);
    var textView2 = new TextView(layout.Context) { Id = 123 };
    //param.AddRule(LayoutRules.Below, textView2.Id);
    textView2.Text = "0000000000000";
    //textView2.SetX(300);
    //textView2.SetY(300);
    //textView2.ScaleY = 300;
    //textView2.ScaleX = 300;
    //textView2.TextSize = 30;
    //textView2.SetWidth(300);
    //textView2.SetHeight(300);
    layout.AddView(textView2/*, param*/);
    //layout.Invalidate();
    //var newTx = FindViewById<TextView>(123);
    //var TextTest = newTx.Text;
