        [HttpGet]
        [ProducesResponseType(typeof(IList<Currency>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _typeService.GetCurrenciesAsync().ConfigureAwait(false));
        }
        [HttpGet("{id}", Name = "GetCurrency")]
        [ProducesResponseType(typeof(Currency), 200)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await _expenseService.GetCurrencyAsync(id).ConfigureAwait(false));
        }
