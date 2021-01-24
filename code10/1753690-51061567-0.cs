    <Entry DisplayName="Test Methods">
      <Entry.Match>
        <And>
          <Kind Is="Method" />
          <Or>
            <HasAttribute Name="TestMethod" />
            <HasAttribute Name="DataTestMethod" />
          </Or>
        </And>
      </Entry.Match>
      <Entry.SortBy>
      </Entry.SortBy>
    </Entry>
