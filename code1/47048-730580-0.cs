    public override void Draw() {
       Button btn = MyControl as Button;
       if (btn != null) {
          Draw(btn);
       } else {
          Draw(this.MyControl);
       }
    }
