    <class name="Parent">
      <id ..
      <property name="IsDeleted" type="System.Boolean">
        <column name="IsDeleted" />
      </property>
      <joined-subclass name="Child">
        <key>
          <column name="ParentId" />
        </key>
        **<filter-def name="SoftDeleteableFilter" condition="(IsDeleted = 0 or IsDeleted is null)" />**
      </joined-subclass>
      **<filter-def name="SoftDeleteableFilter" condition="(IsDeleted = 0 or IsDeleted is null)" />**
    </class>
