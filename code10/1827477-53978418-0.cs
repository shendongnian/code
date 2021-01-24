    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace find_mot{
    
        class Program{
            static string userWord;
    
            static void Main(string[] args){
                
                string userw = inputWord();
                List<string> liste_finale = Listing() ;
                List<string> anAgList = new List<string>();
                int i = 0;
    
                foreach (string word in liste_finale){ /* we apply "Tri()" on both userinput and the whole list of corresponding words
                                                           to see if some of them match */
                    string u = Tri(userw);
                    string u2 = Tri(word);
                    
                    
                    if (u == u2){ /* if it match = anagram found ! then add this (word) to anAgList */
    
                        Console.WriteLine("found");
                        anAgList.Add(word);
                        i += 1;
                    }
                }
                if (i == 0) /* if no anagram were found , we tell the user */
                {
                    Console.WriteLine("No anagrams found for {0}", userw);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine( i + " anagrams were found for " + userw);
                    foreach (string ana in anAgList) /* we print the anagrams from newly created anAgList */
                    {
                        Console.WriteLine(ana);
                    }
                    Console.ReadLine();
                }
            }
    
            static List<string> Listing (){
    
                /* Creates a list of all the words with the same length as the user 
                 * input, the list is created from txt files that i've got in a 
                 * specific path,
                 * after testing this function works as intended */
    
                List<string> liste_fin = new List<string>();
                int len = userWord.Length;
                string lenS = len.ToString();
                string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o",
                                       "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    
                for (int i = 0; i < alphabet.Length; i+=1){
                    string path = "C:/Users/asus/Desktop/prog python/charm/all_" + alphabet[i] + lenS;
                    string[] allLetters = File.ReadAllLines( path, Encoding.GetEncoding("iso-8859-1")); /* Latin-1 cuz this is a french dictionary */
                    liste_fin.AddRange(allLetters);
                }
                return liste_fin;
            }
    
            public static string inputWord(){
    
                /* input taken from user , works fine */
    
                Console.WriteLine("Entrez un mot dont vous voulez tous les anagrammes:");
                userWord = Console.ReadLine();
                return userWord;
            }
    
            public static string Tri(string args ){
    
                /* this function takes a word and return an alphabeticaly sorted version of it, this works fine too when tested */
    
                char[] array1 = args.ToCharArray();
                Array.Sort(array1);
                string sortedWord = new string(array1);
                return sortedWord;
    
            }
        }
    }
