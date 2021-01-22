    interface ICreature
    {
        /// <summary>
        ///     Creature's age
        /// </summary>
        /// <returns>
        ///     From 0 to int.Max
        /// </returns>
        int GetAge();
    }
    interface IHuman : ICreature
    {
        /// <summary>
        ///     Human's age
        /// </summary>
        /// <returns>
        ///     From 0 to 999
        /// </returns>
        new int GetAge();
    }
