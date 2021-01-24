        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using Nethereum.Web3;
        using System.Threading.Tasks;
    
        namespace ConsoleApp1
        {
            class Program
            {
    
                static void Main(string[] args)
                {
                     Bananas().Wait();
                }
    
                static private async Task Bananas()
                {
                    var publicKey = "0xC0b4ec83028307053Fbe8d00ba4372384fe4b52B";
                    var web3 = new Nethereum.Web3.Web3("https://ropsten.infura.io/myInfura");
                    //var txCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(publicKey);
                    var balance = await web3.Eth.GetBalance.SendRequestAsync(publicKey);
                    var etherAmount = Web3.Convert.FromWei(balance.Value);
    
                    Console.WriteLine(web3);
                    Console.WriteLine("Get txCount " + etherAmount);
                    Console.ReadLine();
                }
            }
        }
