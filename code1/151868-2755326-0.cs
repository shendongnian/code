    public class Test3ViewModel
    {
        [StringLength(3)]
        public string AAA { get; set; }
    }
    [HttpPost]
    public int Test3(Test3ViewModel model)
    {
        if (ModelState.IsValid)
        {
            return 1;
        }
        return 2;
    }
