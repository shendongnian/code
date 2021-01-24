    var node = new Node("root")
    {
        {
            "United States", 
             new Node("Steel")
             {
                 {
                     "ASTM A36",
                     new Node("Grade 36")
                 }
             },
             new Node("Concrete")
             {
             }
        }
    };
    Console.WriteLine(node["United States"].Children.Count);
    Console.WriteLine(node["United States"]["Steel"]["ASTM A36"].Children[0].Text);
