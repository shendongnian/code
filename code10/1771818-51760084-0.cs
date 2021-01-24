        class All_Buttons
        {
            void create_button1(Form1 form)
            {
                Button b1 = new Button();
                b1.Size = new Size(50, 50);
                b1.Location = new Point(10, 10);
                b1.Visible = true;
                b1.Text = "Button1";
                form.Control.Add(b1);
            }
        }
