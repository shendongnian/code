    using System.Linq;
    int[] Code = {2, 1, 1, 1, 1, 2};
    int[] Guess = {2, 2, 1, 2, 2, 1};
    int total =
         Guess.Select((g, i) => new {g, i})
        .Where(x => x.g != Code[x.i])
        .Select(x => x.g).Distinct().Count();
