    This is my code I resolved it by, I used a while loop.
    
    using System;
    
    namespace Game2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                {
                    // This is the to allow random numbers to be created
                    Random rand = new Random(DateTime.Now.Millisecond);
                    Random ran1 = new Random(DateTime.Now.Millisecond);
                    Random ran2 = new Random(DateTime.Now.Millisecond);
                    Random ran3 = new Random(DateTime.Now.Millisecond);
                    Random ran4 = new Random(DateTime.Now.Millisecond);
                    //this is my integer which will hold my data
                    int people = 100, landPrice = 0;
                    int foodIn = 000, landIn = 0000, landOut = 0000, seeds = 0;
                    int foodCost = 20, food = 2800, totalFoodCost = 0000;
                    int year = 1;
                    int land = 1000;
                    int newPeople = 0;
                    int peopleDied = 0;
                    int seedCost = 0;
                    int rats = 0;
                    int peopleSell = 0;
                    double landFinal = 0;
                    peopleSell = people * 10;
                    //game rules and start of game
                    Console.WriteLine("Game Rules! ");
                    Console.WriteLine("The game lasts 10 years, with a year being one turn. ");
                    Console.WriteLine("Each year, enter how many bushels of grain to allocate to buying (or selling) acres of land, feeding your population, and planting crops for the next year ");
                    Console.WriteLine("Each person needs 20 bushels of grain each year to live and can till at most 10 acres of land. ");
                    Console.WriteLine("Each acre of land requires one bushel of grain to plant seeds. ");
                    Console.WriteLine("The price of each acre of land fluctuates from 17 bushels per acre to 26 bushels. ");
                    Console.WriteLine("If the conditions in your country ever become bad enough, the people will overthrow you and you won't finish your 10 year term. ");
                    Console.WriteLine("If you make it to the 11th year, your rule will be evaluated ");
                    Console.WriteLine();
                    Console.WriteLine("TRY YOUR HAND AT GOVERNING ANCIENT SUMERIA");
                    Console.WriteLine("SUCCESSFULLY FOR A 10 YEAR TERM OF OFFICE.");
                    Console.WriteLine();
                    Console.WriteLine("HAMURABI:  I BEG TO REPORT TO YOU,");
                    Console.WriteLine();
                    // loop to add + 1 to year if year is <= 10 and people > 0
                    while (year <= 10 && people > 0)
                    {
                        // this will random gen a number between 17 and 26
                        landPrice = rand.Next(17, 26);
                        Console.WriteLine("Year " + year + " In Charge.");
                        Console.WriteLine();
                        Console.WriteLine("You Harvested " + seeds + " Bushels.");
                        Console.WriteLine(newPeople + " People Came To The City.");
                        Console.WriteLine(peopleDied + " Died In The City.");
                        Console.WriteLine("Rats Have Eaten " + rats + " Bushels.");
                        people = people + newPeople;
                        people = people - peopleDied;
                        Console.WriteLine("The City's Population Is Now " + people + ".");
                        Console.WriteLine("The City Owns " + land + " Acres.");
                        food = seeds + food;
                        food = food - rats;
                        Console.WriteLine("You Now Have " + food + " Bushels In Storage.");
                        Console.WriteLine("Land is trading at " + landPrice + " Bushels per Acre.");
                        Console.WriteLine();
                        landFinal = ((double)land / people);
                        //start of game
                        // Section for user to enter how many acres would like to buy
                        Console.Write("How Many Acres Would You Like To Buy? ");
                        landIn = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        // this will random gen a number between 1 and 10 and 0 and 5 and so on.
                        newPeople = ran1.Next(1, 10);
                        peopleDied = ran2.Next(0, 5);
                        rats = ran3.Next(50, 500);
                        // loop if landIn * landPrice > food or landIn < 0 will show error and ask user to input again
                        while (landIn * landPrice > food || landIn < 0)
                        {
                            Console.WriteLine("You Dont Have Enough Bushels!! ");
                            Console.Write("PLEASE RE ENTER: How Many Acres Would You Like To Buy? ");
                            landIn = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }
                        // loop if landIn * landPrice < food  then allows user to go on and shows summary
                        if (landIn * landPrice < food)
                        {
                            food = food - landPrice * landIn;
                            land = landIn + land;
                            Console.WriteLine("You Bought " + landIn + " Acres.");
                            Console.WriteLine("You Own " + land + " Acres.");
                            Console.WriteLine("You Have " + food + " Bushels Left.");
                            Console.WriteLine();
                        }
                        // Section for user to enter how many acres would like to sell
                        Console.Write("How Many Acres Would You Like To Sell? ");
                        landOut = int.Parse(Console.ReadLine());
                        // loop if land < landOut or landIn < 0 will show error and ask user to input again
    
                        Console.WriteLine();
                        while (land < landOut || landOut < 0)
                        {
                            Console.WriteLine("You Dont Own Enough Acres!!");
                            Console.Write("RE ENTER How Many Acres Would You Like To Sell? ");
                            landOut = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }
                        //if the loop condition is met will allow user to carry on.
                        if (landOut < land || landOut == land)
                            land = land - landOut;
                        food = food + landPrice * landOut;
                        {
                            Console.WriteLine("You Sold " + landOut + " Acres.");
                            Console.WriteLine("You Own " + land + " Acres.");
                            Console.WriteLine("You Now Have " + food + " Bushels.");
                            Console.WriteLine();
                        }
                        // Section for user to enter how many bushel to feed their people.
                        Console.Write("How Many Bushels Would You Like To Feed Your People? ");
                        foodIn = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        //  Section if condition not met user will have to re enter value
                        while (foodIn > food || foodIn < 0)
                        {
                            Console.WriteLine("You Dont Have Enough Bushels!!");
                            Console.Write("RE ENTER How Many Bushels Would You Like To Feed Your People?  ");
                            foodIn = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }
                        totalFoodCost = people * foodCost;
                        // if condition met user can carry on
                        if (foodIn >= totalFoodCost && foodIn <= food)
                        {
                            Console.WriteLine("Your People Have Eaten.");
                            Console.WriteLine();
                            food = food - foodIn;
                            Console.WriteLine("You Have " + food + " Bushels Left.");
                            Console.WriteLine();
                        }
                        //  Section if condition not met user will have to re enter values
                        else if (foodIn < totalFoodCost)
                        {
                            Console.WriteLine("You Have Been Over Thrown As People Are Hungry - Please Restart! ");
                            return;
                        }
                        Console.Write("How Many Acres Do You Wish To Plant With Seed? ");
                        seeds = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        seedCost = (people * 10);
                        while (seeds > seedCost || seeds < 0)
                        {
                            Console.WriteLine("You Dont Have Enough People! ");
                            Console.Write("How Many Acres Do You Wish To Plant With Seed?  ");
                            seeds = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }
                        if (seeds < seedCost && seeds < food)
                        {
                            Console.WriteLine("You Have Planted " + seeds + " Seeds.");
                            food = food - seeds;
                            Console.WriteLine("You Now Have " + food + " Bushels.");
                            Console.WriteLine();
                        }
                        while (land == 1 || seeds > land || seeds < 0)
                        {
                            Console.WriteLine("You Dont Have Enough Land!!");
                            Console.Write("How Many Acres Do You Wish To Plant With Seed?  ");
                            seeds = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }
                        while (seeds > food || seeds < 0)
                        {
                            Console.WriteLine("You Dont Have Enough Bushels!!");
                            Console.Write("How Many Acres Do You Wish To Plant With Seed?  ");
                            seeds = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }
                        food = food - seeds;
                        seeds = seeds * rand.Next(2, 8);
                        //end of year summary will loop untill year 11.
                        Console.WriteLine("End Of Year " + year + ".");
                        year = year + 1;
                        Console.WriteLine();
                        Console.WriteLine("You Ended With " + food + " Bushels.");
                        Console.WriteLine("You Ended With " + land + " Acres.");
                        Console.WriteLine();
    
                        landFinal = ((double)land / people);
                        // end of year final summary
                        if (year == 11)
                        {
                            Console.WriteLine("Congratulations On Reaching The End Of Your Term!");
                            Console.WriteLine();
                            Console.WriteLine("You Ended With " + food + " Bushels.");
                            Console.WriteLine("You Ended With " + land + " Acres.");
                            Console.WriteLine("You Ended With " + people + " People.");
                            Console.WriteLine("Each Person Ended With " + landFinal + " Per Acre.");
                            Console.WriteLine();
                            landFinal = ((double)land / people);
                        }
                        //failed year summary 
                        if (year == 11 && landFinal < 10)
                        {
                            Console.WriteLine("You Have Been Marked As A Failure For Your Service!!");
                            return;
                        }
                        //sucessful game summary 
                        if (year == 11 && landFinal >= 10)
                        {
                            Console.WriteLine("You Are A Great King!!");
                            return;
                        }
    
                    }
                }
            }
        }
    }
