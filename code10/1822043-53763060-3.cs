    public class WinAnimation
    {
        private readonly FlashingPictureBox[] boxes;
        private readonly int started;
        const int singleFlashDuration = 700;
        const int nextBoxDelay = 100;
        const int duration = 3000;
        public WinAnimation(params FlashingPictureBox[] boxes)
        {
            this.boxes = boxes;
            started = Environment.TickCount;
        }
        /// <summary>
        /// Performs the animation at the indicated point in time.
        /// </summary>
        /// <param name="elapsed">The time elapsed since the animation started, in milliseconds</param>
        /// <returns>true if the animation is running, false if the animation is completed</returns>
        public bool Animate()
        {
            int elapsed = Environment.TickCount - started;
            if (elapsed >= duration)
            {
                foreach (var box in boxes)
                {
                    box.FlashIntensity = 0;
                }
                return false;
            }
            for (int i = 0; i < boxes.Length; i++)
            {
                var box = boxes[i];
                int boxElapsed = elapsed - i * nextBoxDelay;
                if (boxElapsed < 0)
                {
                    box.FlashIntensity = 0;
                }
                else
                {
                    int intensity = (boxElapsed % singleFlashDuration);
                    intensity = (intensity * 255) / singleFlashDuration;
                    box.FlashIntensity = intensity;
                }
            }
            return true;
        }
    }
