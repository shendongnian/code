        private Thumb mThumb = null;
        public Thumb Thumb
        {
            get { return mThumb; }
            set
            {
                if (mThumb != value)
                {
                    if (mThumb != null)
                    {
                        DetachThumb();
                    }
                    mThumb = value;
                    if (mThumb != null)
                    {
                        AttachThumb();
                    }
                }
            }
        }
        private void AttachThumb()
        {
            Thumb.DragStarted += Thumb_DragStarted;
            Thumb.DragDelta += Thumb_DragDelta;
            Thumb.DragCompleted += Thumb_DragCompleted;
        }
        private void DetachThumb()
        {
            Thumb.DragStarted -= Thumb_DragStarted;
            Thumb.DragDelta -= Thumb_DragDelta;
            Thumb.DragCompleted -= Thumb_DragCompleted;
        }
        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            mIsThumbDragging = true;
            mPreviousDiffX = 0;
            mPreviousDiffY = 0;
        }
        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (mIsMoving)
            {
                return;
            }
            mIsMoving = true;
            try
            {
                if (mIsThumbDragging)
                {
                    var doubleDetaX = e.HorizontalChange + mPreviousDiffX;
                    var doubleDetaY = e.VerticalChange + mPreviousDiffY;
                    var deltaX = (int)doubleDetaX;
                    var deltaY = (int)doubleDetaY;
                    mPreviousDiffX = (double)deltaX - doubleDetaX;
                    mPreviousDiffY = (double)deltaY - doubleDetaY;
                    HostPopup.Move(deltaX, deltaY);
                }
            }
            finally
            {
                mIsMoving = false;
            }
        }
        private void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            mIsThumbDragging = false;
        }
        #endregion
