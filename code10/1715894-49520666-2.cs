        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X - panel1.Left < 20 && e.Y - panel1.Top < 20)
            {
                Cursor.Position = CenterPoint(panel1);
                Console.WriteLine($"{e.X} {e.Y}");
            }
        }
