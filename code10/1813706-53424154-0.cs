            private void timer1_Tick(object sender, EventArgs e)
            {
                if (!(Y1Green > 50 || X1Green > 320 || X2Green > 250 || Y2Green > 180))
                {
                    timer1.Stop();
                    timer2.Start();
                    return;
                }
    
                // Moving the Green Triangle Diagonally to the Light Blue Triangle
                if (Y1Green > 50) { Y1Green -= 3; }
                if (X1Green > 320) { X1Green -= 5; }
                if (X2Green > 250) { X2Green -= 5; }
                if (Y2Green > 180) { Y2Green -= 3; }
                Draw();
            }
    
            private void timer2_Tick(object sender, EventArgs e)
            {
                if (!(X1Blue < 450 || X2Blue < 320 || Y1PaleGreen < 180 || Y2PaleGreen < 250))
                {
                    timer2.Stop();
                    return;
                }
                //Moving our Blue Triangle
                if (X1Blue < 450) { X1Blue += 2; }
                if (X2Blue < 320) { X2Blue += 2; }
    
                //Moving our Pale Green Triangle
                if (Y1PaleGreen < 180) { Y1PaleGreen += 4; }
                if (Y2PaleGreen < 250) { Y2PaleGreen += 4; }
    
                Draw();            
            }
