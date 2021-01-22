    private void button4_Click(object sender, EventArgs e)
    {
        test(new { a = "asd" });
    }
    private void test(dynamic obj)
    {
        Console.WriteLine(obj.a);
    }
