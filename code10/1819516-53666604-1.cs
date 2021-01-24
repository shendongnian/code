    public byte[] Member_Picture { get; set; }
    public string Image
    {
        get
        {
            return String.Format("data:image/png;base64,{0}", Convert.ToBase64String(Member_Picture));
        }
    }
