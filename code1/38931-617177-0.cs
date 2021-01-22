        /// <summary>
        /// Thread in charge of feeding the playback buffer.
        /// </summary>
        private void playbackThreadFn()
        {
            // Begin playing the sound buffer.
            m_playbackBuffer.Play( 0, BufferPlayFlags.Looping );
            // Change playing state.
            IsPlaying = true;
            // Playback loop.
            while( IsPlaying )
            {
                // Suspend thread until the playback cursor steps into a trap...
                m_trapEvent.WaitOne();
                // ...read audio from the input stream... (In this case from your pink noise buffer)
                Input.Collect( m_target, m_target.Length );
                // ...calculate the next writing position...
                var writePosition = m_traps[ ((1 & m_pullCounter++) != 0) ? 0 : 1 ].Offset;
                // ...and copy audio to the device buffer.
                m_playbackBuffer.Write( writePosition, m_deviceBuffer, LockFlag.None );
            }
            // Stop playback.
            m_playbackBuffer.Stop();
        }
