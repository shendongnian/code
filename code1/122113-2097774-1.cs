            bar a = new bar();
            // returns bar
            literalTest1.Text = a.Test;
            foo b = new foo();
            // returns "foo"
            literalTest2.Text = b.Test;
            foo c = new bar();
            // returns "foo"
            literalTest3.Text = c.Test;
            
