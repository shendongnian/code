csharp
using System;
using System.Text;
using Nethereum.Hex.HexConvertors.Extensions;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.RPC.Eth.Blocks;
using Nethereum.Hex.HexTypes;
public class HexDecoding
{
    private static async Task Main(string[] args)
    {
        var web3 = new Web3("your url");
        var work = await web3.Eth.Mining.GetWork.SendRequestAsync();
				Console.WriteLine(work.Length);       
    }
}
