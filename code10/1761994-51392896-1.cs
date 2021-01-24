    class IntContainer { public int val;}            //class with int field 
    IntContainer num = new IntContainer {val = 1};   //original set to 1
    IntContainer[] nums = new[] {num};
    nums[0].val = 200;                               //setting the array element
    Console.WriteLine(num.val);                      //200 not 1 
