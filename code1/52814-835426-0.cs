        /// <summary>
        /// Retrieve the tickets information for the specified order
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <returns>Tickets data</returns>
        [OperationContract]
        TicketsDto GetTickets(int orderId);
