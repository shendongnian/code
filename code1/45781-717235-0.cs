    // this line should be in class body, not in method
    delegate void MyDelegate(); 
    var Obj = new {
        MyDel = new MyDelegate(delegate() { MessageBox.Show("yee-haw"); })
    };
    Obj.MyDel();
