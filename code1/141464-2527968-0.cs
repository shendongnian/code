        int ThisColor { get; set; }
        public void ChangeColor(Func<int> getter, Action<int> setter)
        {
            setter(getter() + 5);
        }
        public void SomeMethod()
        {
            ChangeColor(() => ThisColor, (color) => ThisColor = color);
        }
