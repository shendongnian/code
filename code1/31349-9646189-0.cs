    public static void PerformClick(this Control value)
        {
            if (value == null)
                throw new ArgumentNullException();
            var methodInfo = value.GetType().GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(value, new object[] { EventArgs.Empty });
        }
