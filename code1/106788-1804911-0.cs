    class Timezone
    {
      DateTime start;
      int hourlyWeights[6]; //assuming you have 6 hour long timeslot for every timezone
      
      DateTime GetStartTime(long clientId)
      {
        long allTicks = 3600*sum(hourlyWeights);
        long clientTicks = clientId%allTicks;
        int i = 0;
        while(clientTicks>hourlyWeights[i])
        {
          clientTicks -= hourlyWeights[i]*3600;
          i++;
        }
        long seconds = clientTicks/hourlyWeights[i];
        return start.AddHours(i).AddSeconds(seconds);
      }
    }
