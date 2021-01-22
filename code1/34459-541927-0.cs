    TextBox[] foos = new TextBox[] { foo1, foo2, foo3, /* etc */ };
    TextBox[] bars = new TextBox[] { bar1, bar2, bar3, /* etc */ };
    
    for (int i = 0; i <= 10; i++)
        if (foos[i].Text.Length != 0 && bars[i].Text.Length != 0)
            output.Text += myStrings[i] + "/" + foos[i].Text + bars[i].Text;
