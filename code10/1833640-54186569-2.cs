    catch
    {
      textBox9.Text = "Invalid File";
      textBox9.BackColor = Color.Red;
      textBox9.Visible = true;
      int seconds = 3;
            if (seconds < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < _desired)
            {
                 System.Windows.Forms.Application.DoEvents();
            }
      textBox9.Visible = false;
    }
