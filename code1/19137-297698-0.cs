            /// <summary>
        /// Clears Text from Controls...ie TextBox, Label, anything that implements ITextBox
        /// </summary>
        /// <typeparam name="T">Collection Type, ie. ContentPlaceHolder..</typeparam>
        /// <typeparam name="C">ie TextBox, Label, anything that implements ITextBox</typeparam>
        /// <param name="controls"></param>
        public static void Clear<T, C>(ControlCollection controls)
            where C : ITextControl
            where T : Control
        {
            IEnumerable<T> placeHolders = controls.OfType<T>();
            List<T> holders = placeHolders.ToList();
            foreach (T holder in holders)
            {
                IEnumerable<C> enumBoxes = holder.Controls.OfType<C>();
                List<C> boxes = enumBoxes.ToList();
                foreach (C box in boxes)
                {
                    box.Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// Clears the text from control.
        /// </summary>
        /// <typeparam name="C"></typeparam>
        /// <param name="controls">The controls.</param>
        public static void ClearControls<C>(ControlCollection controls) where C : ITextControl
        {
            IEnumerable<C> enumBoxes = controls.OfType<C>();
            List<C> boxes = enumBoxes.ToList();
            foreach (C box in boxes)
            {
                box.Text = string.Empty;
            }
        }
