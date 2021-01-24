        private void CreateBuffer()
        {       
            if (_buffer == null || _buffer.Size != ClientSize)
            {
                this._buffer?.Dispose();
                _buffer = new Bitmap( ClientSize.Width, ClientSize.Height );
            }
        }
        protected override void OnPaint( PaintEventArgs e )
        {
            CreateBuffer();
            if (_is_dirty)
            {
                using (Graphics g = Graphics.FromImage( _buffer ))
                {       
                    RenderEventArgs ev = new RenderEventArgs( _buffer, g );
                    OnRender( ev ); /* Do your drawing here */
                    _is_dirty = False;
                }
            }
            e.Graphics.DrawImage( _buffer, 0, 0 );
        }   
