    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Checkpoint_III
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string[] questions =            //these are the questions for the quiz
                {
    "1)  On which day was the United States Marine Corps born?",
    "2)  Where was the Marine Corps founded?",
    "3) Robert Mullen was the first Marine Corps Recruiter.",
    "4)  Who was the Grand Old Man of the Marine Corps?",
    "5)  Marines are also referred to as “Devil Cats.”",
    "6)  Who was the first Commandant of the Marine Corps?",
    "7)  What is the Mascot of the Marine Corps?",
    "8)  The Blood Stripe worn by Marines is to signify the blood shed during the Battle of Chapultepec.",
    "9)  What is the Marine Corps motto?",
    "10)  Marines have often been referred to as “Leathernecks” due to the high leather collars worn to combat sword slashes."
    };
    
                string[] answers =          //these are the selections for each of the questions
                {
    "   a)   10 November 1776\n   b)   4 July 1776\n   c)   10 November 1775\n   d)   8 December 1777\n",
    "   a)   The White House, Washington D.C.\n   b)   Tuns Tavern, Philadelphia, PA\n   c)   Marine Corps Base Quantico, VA\n   d)   MCRD Parris Island, Beaufort, SC\n",
    "   True\n   False\n",
    "   a)   Archibald Henderson\n   b)   Chesty Puller\n   c)   Samuel Nichols\n   d)   Dan Daly\n",
    "   True\n   False\n",
    "   a)   Chesty Puller\n   b)   Samuel Nichols\n   c)   Ophae Mae Johnson\n   d)   None of the above\n",
    "   a)   Pitbull\n   b)   Rottweiler\n   c)   English Bulldog\n   d)   German Shepard\n",
    "   True\n   False\n",
    "   a)   “Be Prepared”\n   b)   “Do a Good Turn Daily”\n   c)   “Semper Fidelis”\n   d)   None of the above\n",
    "   True\n   False\n",
    };
    
                string[] correctanswer =            //these are the correct answers for the questions
                {
    "c",
    "b",
    "t",
    "a",
    "f",
    "b",
    "c",
    "t",
    "c",
    "t"
    };
    
                string[] validanswer =              //These are the valid inputs accepted to not recieve error message
                {
                    "a", "b", "c", "d", "t", "f", "A", "B", "C", "D", "T", "F"
                };
    
    
    
                int score = 0; //The initializing of the score board. Player starts at 0 while each question is worth 10 points. Final score will be out of 100.
    
                int[] questionsIncorrect = new int[10];
    
                //This is the beginning of my quiz program
    
                Console.WriteLine("Jon Smith");
                Console.WriteLine("Classwork");
                Console.WriteLine("CP4\n");
                Console.WriteLine("Marine Corps History Quiz\n");
                Console.WriteLine("There are a series of multiple choice and true/false questions\n");
                Console.WriteLine("Input the letter of the selection for multiple choice");
                Console.WriteLine("For true/false, enter t or f\n");
                Console.WriteLine("Shall we begin?");
    
                Console.WriteLine();
                int j = -1;
                string check;
                Console.WriteLine("Round One");
    
    
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Q{0}", questions[i]);
                    Console.WriteLine("{0}", answers[i]);
                    Console.WriteLine("Enter Answer :: ");
                    check = Console.ReadLine();
                    Console.WriteLine();
    
                    //Begin error message code
                    if (!validanswer.Contains(check))
                    {
                        Console.WriteLine("Invalid Entry");
                        Console.WriteLine("Enter Answer :: ");
                        while (validanswer.Contains(check) == false)
                        {
                            //End error message code
    
                            check = Console.ReadLine();
                            if (check.Equals(correctanswer[i]))
                            {
                                score = score + 10;
                            }
                            else
                            {
                                j++;
                                questionsIncorrect[j] = i;
                            }
                        }
                    }
                    else
                    {
                        if (check.Equals(correctanswer[i]))
                        {
                            score = score + 10;
                        }
                        else
                        {
                            j++;
                            questionsIncorrect[j] = i;
                        }
                    }
    
                   
                }
                int k;
                if (j > -1)
                {
                    Console.WriteLine("Round II");
                    for (int i = 0; i <= j; i++)
                    {
                        k = questionsIncorrect[i];
                        Console.WriteLine("Q{0}", questions[k]);
                        Console.WriteLine("{0}", answers[k]);
                        Console.WriteLine("Enter Answer :: ");
                        check = Console.ReadLine();
                        Console.WriteLine();
                        if (check.Equals(correctanswer[k]))
                        {
                            score = score + 10;
                        }
                        else
                        {
                            Console.WriteLine("Correct Answer is {0}", correctanswer[k]);
                        }
                    }
                }
                Console.WriteLine("Score is {0}%", score);
                Console.ReadKey();
            }
    
        }
    
    }
