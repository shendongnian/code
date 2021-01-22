        /// <summary>
        /// Starts playing the movie, or resumes
        /// it if it is paused.
        /// </summary>
        public void Play()
        {
            Stop();
            flash_control.Play();
        }
        /// <summary>
        /// Pauses the movie. To resume it, 
        /// call <see cref="Play()"/>.
        /// </summary>
        public void Pause()
        {
            flash_control.Stop();
        }
        /// <summary>
        /// Stops playing the movie
        /// </summary>
        public void Stop()
        {
            flash_control.Stop();
            flash_control.FrameNum = 0;
        }
