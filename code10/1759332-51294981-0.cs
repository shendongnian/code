     public void displayPressureCenter(double[,] pressureMatrix, Plot plot, PictureBox pictureBox)
     {
          if ( pictureBox.InvokeRequired )
          {
              this.Invoke(delegate { displayPressureCenter(pressureMatrix, plot, pictureBox)});
              exit;
          }
                //Get matrix size
                int xSize = pressureMatrix.GetLength(0);
                int ySize = pressureMatrix.GetLength(1);
                try
                {
                    //Get CoP and move pictureBox
                    System.Windows.Point centerOfPressure = getCenterOfPressure(pressureMatrix);
                    pictureBox.Visible = true;
                    pictureBox.Parent = plot.plotView;
                    //Calculamos el punto dónde hay que printar utilizando una regla de 3 y descontando la mitad del tamaño de la señal (para que quede centrada)
                    System.Drawing.Point displayPositionCart = new System.Drawing.Point((int)Math.Round((centerOfPressure.X * plot.plotView.Width / xSize) - (pictureBox.Width / 2)), (int)Math.Round((centerOfPressure.Y * plot.plotView.Height / ySize) - (pictureBox.Height / 2)));
                    //Pasamos a coordenadas de pantalla y aplicamos un offset para quitar el eje
                    System.Drawing.Point displayPositionScre = CartesianToScreenCoordinates(displayPositionCart, plot.plotView);
                    displayPositionScre.Offset(0, -70);
                    pictureBox.Location = displayPositionScre;
                }
                catch (Exception e)
                {
                     throw e;
                }
      // Rest of your code
