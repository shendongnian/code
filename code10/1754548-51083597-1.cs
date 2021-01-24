    public HttpResponseMessage GetDetails(string msn, DateTime dt)
    {
        try
        {
            int mainCount = giveMainCount(msn, dt);
            if (mainCount == 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { details = null });
            }
            int mainInterval = mainCount / 500;
            var mainDetails = kesc.tj_xhqd
                            .AsNoTracking()
                            .Where(m => (m.zdjh == msn) && (m.sjsj >= dt))
                            .AsEnumerable()
                            .Select((x, i) => new { MSN = x.zdjh, PingDateTime = x.sjsj, PingValue = x.xhqd, i = i })
                            .Where(x => x.i % mainInterval == 0)
                            .ToList();
            return Request.CreateResponse(HttpStatusCode.OK, new { details = mainDetails });
        }
        catch (Exception ex)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        }
    }
