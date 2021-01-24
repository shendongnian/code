    using System.Collections.Generic;
    ...
    private static async IAsyncEnumerable<int> GetNumbersAsync() {
        var nums = Enumerable.Range(0, 10);
        await foreach (var num in nums.ToAsync()) {
            await Task.Delay(100);
                yield return num;
            }
        }
    }
