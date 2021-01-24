        Dim xe1 As XElement
        Dim xe2 As XElement
        xe1 = <CurrentStatus>
                  <Time Stamp="12:30">
                      <price>100</price>
                      <amount>1</amount>
                  </Time>
                  <Time Stamp="14:50">
                      <price>10</price>
                      <amount>5</amount>
                  </Time>
                  <Time Stamp="16:30">
                      <price>10</price>
                      <amount>5</amount>
                  </Time>
              </CurrentStatus>
        xe2 = <CurrentStatus>
                  <Time Stamp="17:22">
                      <price>40</price>
                      <amount>120</amount>
                  </Time>
              </CurrentStatus>
        xe1.Add(xe2.<Time>) 'add to end
        ' OR
        ' xe1.AddFirst(xe2.<Time>) 'first
