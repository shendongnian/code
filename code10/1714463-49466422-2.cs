     public Form1()
        {
            InitializeComponent();
           // graphics = this.drawingArea.CreateGraphics();
            this.Paint += new System.Windows.Forms.PaintEventHandler(DrawLines);
        }
        public void DrawLines(object sender, PaintEventArgs e)
        {
            Graphics g;
            
            g = e.Graphics;
            // Create points that define line.
            for (int i = 0; i < lineCount; i++)
            {
                for (int j = 1; j < stationCount; j++)
                {
                    int stationID1 = stationNumber[i, j];
                    int stationID2 = stationNumber[i, j + 1];
                    if (stationID2 > 0)
                    {
                        for (int s = 0; s < stationCount; s++)
                        {
                            if (stationID1 == stationID[s])
                            {
                                Point start = new Point(stationX[s], stationY[s]);
                            }
                            if (stationID2 == stationID[s])
                            {
                                Point end = new Point(stationX[s], stationY[s]);
                            }
                        }
                        DrawLinePoint(lineName[i], g, start, end);
                    }
                }
            }
        }
