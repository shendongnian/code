    splitBox.Panel1.BackColor = splitBox.Panel1.BackColor;
    splitBox.Panel2.BackColor = splitBox.Panel2.BackColor;
    splitBox.BackColor = Color.SomeColor;
    splitBox.SplitterWidth = 2; // up to you what looks best
    splitBox.TabStop = false;
    splitBox.Enter += (s, e) =>
       splitBox
       .FindForm()
       ?.SelectNextControl(splitBox, true, true, true, true);
