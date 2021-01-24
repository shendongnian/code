            var _x = 0;
            var _y = 0;
            if (_x == pictureBox1.Width)
            {
                // Dont Move
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        _x += 50;
                        _objPosition = Position.Right;
                        break;
                    case Keys.A:
                        _x -= 50;
                        _objPosition = Position.Left;
                        break;
                }
            }
            if (_y == pictureBox1.Length)
            {
                //Don't Move
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        _y -= 50;
                        _objPosition = Position.Up;
                        break;
                    case Keys.S:
                        _y += 50;
                        _objPosition = Position.Down;
                        break;
                }
            }
