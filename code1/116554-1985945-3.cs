    <Where>
      <And>
        <And>
          <Eq>
            <FieldRef Name='Category'/>
            <Value Type='Choice'>ABC</Value>
          </Eq>
          <Eq>
            <FieldRef Name='Category'/>
            <Value Type='Choice'>ABD</Value>
          </Eq>
        </And>
        <Eq>
          <FieldRef Name='Category'/>
          <Value Type='Choice'>ABE</Value>
        </Eq>
      </And>
    </Where>
