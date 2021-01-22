        public partial class MyButton : Button
        {
            protected override bool IsInputKey(Keys keyData)
            {
                if (keyData == Keys.Right)
                {
                    return true;
                }
                else
                {
                    return base.IsInputKey(keyData);
                }
            }
        }
