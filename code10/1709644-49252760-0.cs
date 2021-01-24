        /// <summary>
        ///  Method that enlargens the kind of object sent in
        /// </summary>
        public void ExponentialGrowth2(string name, float startY, float endY)
        {
            float totalDistance = endY - startY;
            float currentY = 0;
            for (int i = 0; i < Bodies.Bodylist.Count; i++)
            {
                if (Bodies.Bodylist[i].Name.StartsWith(name)) //looks for all bodies of this type
                {
                    currentY = Bodies.Bodylist[i].PosY;
                    float distance = currentY - startY + (float)Bodies.Bodylist[i].circle.Height;
                    float fraction = distance / totalDistance; //such as 0.8
                    Bodies.Bodylist[i].circle.Width = Bodies.Bodylist[i].OriginalWidth * Math.Pow(fraction, 3);
                    Bodies.Bodylist[i].circle.Height = Bodies.Bodylist[i].OriginalHeight * Math.Pow(fraction, 3);
                }
            }
        }
