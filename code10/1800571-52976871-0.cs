    Control Con = FindControl("MyFirstRow");
    LiteralControl LCx = new LiteralControl { ID = "MyFirstRow34" };
    LCx.Text = @"
        <li class='dropdown'>
            <a href='#'>Sample<span class='caret'></span></a>
         </li>";
    Con.Controls.Add(LCx);
    Control myFirstRow34 = FindControl("MyFirstRow34");
