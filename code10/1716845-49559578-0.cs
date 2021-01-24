    var data = _moneyRepository.GetFiltered(filter);
    List<MoneyDto> list = data.GroupBy(_ => new { _.Date, _.ContactId })
        .Select(g => new MoneyDto {
            ContactId = g.Key.ContactId,
            Date = g.Key.Date,
            Sell = g.Where(_ => _.Action == "Sell").Sum(_ => _.Amount),
            Buy = g.Where(_ => _.Action == "Buy").Sum(_ => _.Amount),
        }).ToList();
