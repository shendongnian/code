    public static class Test
    {
        public static void DisalbeMyButton()
        {
            var form = Form.ActiveForm as Form1;
            if (form != null)
            {
                form.MyButton.Enabled = false;
            }
        }
    }
