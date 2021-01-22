    List<MockData> lst = new List<MockData>();
    lst.Add(new MockData() { Name = "Picture 1", Url = "pic1.jpg" });
    lst.Add(new MockData() { Name = "Picture 2", Url = "pic2.jpg" });
    lst.Add(new MockData() { Name = "Picture 3", Url = "pic3.jpg" });
    yourRepeater.DataSource = lst;
    yourRepeater.DataBind();
