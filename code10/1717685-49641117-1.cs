            if (p.VelX > 0)
            {
                Console.WriteLine("Right Collision");
                p.canMove = false;
                //move the right of our player to the left of the wall by setting
                //his x to the wall's x minus his width.
                p.Position.X = w.Position.X - p.Size.Width;
                p.SetVelX(0);
            }
            else if (p.VelX < 0)
            {
                Console.WriteLine("Left Collision");
                p.canMove = false;
                //Move the left of our player to the right of the wall, or
                //the wall's x plus the wall's width
                p.Position.X = w.Position.X + w.Size.Width;
                p.SetVelX(0);
             }
