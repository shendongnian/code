    var allWheels = new List<char[]> { w1, w2, w3, w4, w5 };
    var totalNumCombos = allWheels.Select(w => w.Length).Aggregate(1, (a, n) => a * n);
    
    var numWheels = allWheels.Count;
    var numWheelsm1 = numWheels-1;
    var wheelbase = w1.Length; // use an array for different sized wheels
                               // allWheels.Select(w => w.Length).ToArray();
    var allCombos = new List<string>();
    
    var sbCombo = new StringBuilder(new String(allWheels.ToArray().Reverse().Select(w => w[0]).ToArray()));
    
    for (int aComboInDecimal = 0; aComboInDecimal < totalNumCombos; ++aComboInDecimal) {
        var num = aComboInDecimal;
        for (var digit = 0; digit < numWheels && num > 0; ++digit) {
            var digitVal = num % wheelbase; // wheelbase[digit]
            num = num / wheelbase; // wheelbase[digit]
            sbCombo[numWheelsm1-digit] = allWheels[digit][digitVal];
        }
        allCombos.Add(sbCombo.ToString());
    }
