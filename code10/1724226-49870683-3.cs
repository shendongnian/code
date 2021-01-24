    public class MainClass
    {
        //instantiate the other class
        Program myProgramClass = new Program(); // this is your reference to Program class
        //then use it this way
        myProgramClass.Run(); // this part initialized the driver
        myProgramClass.Do(); // this part used the driver to findElement;
    }
