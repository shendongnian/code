      public async Task<int> CountInPenLot(DateTimeOffset date)
        {
            int total = 0;
            var lotPensSum = await _context.LotPens
                .Where(x => x.DateColumn == date).toList(); //Filter on the date
            var lotHistorySum = await _context.LotHistories
                .Where(x => x.DateColumn == date).toList();
            foreach (var lotPens in lotPensSum)
            {
                if (lotPens.c != null)
                {
                    int intC = 0;
                    int.TryParse(lotPens.c, out intC);
                    total += intC;
                }
            }
            foreach (var lotHistor in lotHistorySum )
            {
                if (lotHistor.c != null)
                {
                    int intC = 0;
                    int.TryParse(lotHistor.c, out intC);
                    total += intC;
                }
            }
        return total;
        }
