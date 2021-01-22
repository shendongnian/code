    public void OuterMethod() {
        someControl.SomeEvent += delegate(int p1, string p2) {
            // this code is inside an anonymous delegate
        }
    }
