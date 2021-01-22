        private void Form1_ResizeBegin(object sender, EventArgs e)
                {
                    panel1.Visible = false;
      Form1.ActiveForm.TransparencyKey = Color.Transparent;
                }
          private void Form1_ResizeEnd(object sender, EventArgs e)
                {
                    panel1.Visible = true;
     Form1.ActiveForm.TransparencyKey = Color.Gray; // or whatever color your form was
                }
