            var certsMapping = Certs
                .ToDictionary(_ => _.ID.ToUpper());
            foreach (Classes.CertOrder.IDS OrderUnitID in Order.AllIDs)
            {
                if (certMapping.TryGetValue(OrderUnitID.ID.ToUpper(), out var cert))
                {
                    Output.add(Cert)
                    OrderUnitID.fulfilled = true;
                }
            }
