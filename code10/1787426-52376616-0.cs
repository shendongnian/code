    public class Enemy
    {
    //Static variables are shared across all instances
    //of a class.
    public static int enemyCount = 0;
    
    public Enemy()
    {
        //Increment the static variable to know how many
        //objects of this class have been created.
        enemyCount++;
    }
    }
