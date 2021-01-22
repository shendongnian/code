    void DoSomething(Control parent) {
        foreach(Control control in parent.Controls) {
            Button btn = control as Button;
            if(btn != null) {
                btn.Text = "hello world";
                // etc
            }
            DoSometing(control); // recurse
        }
    }
