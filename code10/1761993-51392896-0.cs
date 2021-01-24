    class A { public int num;}
    var a = new A {num = 1};     //original set to 1
    var nums = new A[] {a};
    nums[0].num=200;             //setting the array element
    Console.WriteLine(a.num);    //200 not 1 
