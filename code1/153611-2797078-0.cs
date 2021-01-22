    <type type="foo.IMovementRepository,foo" mapTo="foo.MovementRepository,foo">
      <typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement, Microsoft.Practices.Unity.Configuration">     
       <constructor>
         <param name="connectionString" parameterType="System.String" >
           <value value="conectionstring goes here" type="System.String"/>
         </param>           
       </constructor>
      </typeConfig>
    </type>
