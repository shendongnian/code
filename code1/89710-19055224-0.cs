    <Patterns xmlns="urn:shemas-jetbrains-com:member-reordering-patterns">
    <!--  Do not reorder COM interfaces  -->
    <Pattern>
        <Match>
            <And Weight="100">
                <Kind Is="interface" />
                <HasAttribute CLRName="System.Runtime.InteropServices.InterfaceTypeAttribute" />
            </And>
        </Match>
    </Pattern>
    <!--  Special formatting of NUnit test fixture  -->
    <Pattern RemoveAllRegions="true">
        <Match>
            <And Weight="100">
                <Kind Is="class" />
                <HasAttribute CLRName="NUnit.Framework.TestFixtureAttribute" Inherit="true" />
            </And>
        </Match>
        <!--  Setup/Teardow  -->
        <Entry>
            <Match>
                <And>
                    <Kind Is="method" />
                    <Or>
                        <HasAttribute CLRName="NUnit.Framework.SetUpAttribute" Inherit="true" />
                        <HasAttribute CLRName="NUnit.Framework.TearDownAttribute" Inherit="true" />
                        <HasAttribute CLRName="NUnit.Framework.FixtureSetUpAttribute" Inherit="true" />
                        <HasAttribute CLRName="NUnit.Framework.FixtureTearDownAttribute" Inherit="true" />
                    </Or>
                </And>
            </Match>
        </Entry>
        <!--  All other members  -->
        <Entry />
        <!--  Test methods  -->
        <Entry>
            <Match>
                <And Weight="100">
                    <Kind Is="method" />
                    <HasAttribute CLRName="NUnit.Framework.TestAttribute" Inherit="false" />
                </And>
            </Match>
            <Sort>
                <Name />
            </Sort>
        </Entry>
    </Pattern>
    <!--  Default pattern  -->
    <Pattern RemoveAllRegions="false">
        <!--  Delegates  -->
        <Entry>
            <Match>
                <And Weight="100">
                    <Access Is="public" />
                    <Kind Is="delegate" />
                </And>
            </Match>
            <Sort>
                <Access Order="public internal protected-internal protected private" />
                <Name />
            </Sort>
            <Group Region="Delegates" />
        </Entry>
        <!--  Fields and constants  -->
        <Entry>
            <Match>
                <Or>
                    <Kind Is="field" />
                    <Kind Is="constant" />
                </Or>
            </Match>
            <Sort>
                <Access Order="public internal protected-internal protected private" />
                <Kind Order="constant" />
                <Readonly />
                <Static />
                <Name />
            </Sort>
            <Group Region="Fields" />
        </Entry>
        <!--  Enums  -->
        <Entry>
            <Match>
                <Kind Is="enum" />
            </Match>
            <Sort>
                <Access Order="public internal protected-internal protected private" />
                <Name />
            </Sort>
            <Group Region="Enums" />
        </Entry>
        <!--  Constructors. Place static one first  -->
        <Entry>
            <Match>
                <Kind Is="constructor" />
            </Match>
            <Sort>
                <Static />
                <Access Order="public internal protected-internal protected private" />
            </Sort>
            <Group Region="Constructors" />
        </Entry>
        <!--  Destructors. Place static one first  -->
        <Entry>
            <Match>
                <Kind Is="destructor" />
            </Match>
            <Sort>
                <Static />
                <Access Order="public internal protected-internal protected private" />
            </Sort>
            <Group Region="Destructors" />
        </Entry>
        <!--  Events  -->
        <Entry>
            <Match>
                <Kind Is="event" />
            </Match>
            <Sort>
                <Access Order="public internal protected-internal protected private" />
                <Name />
            </Sort>
            <Group Region="Events" />
        </Entry>
        <!--  Properties  -->
        <Entry>
            <Match>
                <And>
                    <Kind Is="property" />
                    <Not>
                        <Kind Is="indexer" />
                    </Not>
                </And>
            </Match>
            <Sort>
                <Access Order="public internal protected-internal protected private" />
                <Static />
                <Abstract />
                <Virtual />
                <Override />
                <Name />
            </Sort>
            <Group Region="Properties" />
        </Entry>
        <!--  Indexers  -->
        <Entry>
            <Match>
                <Kind Is="indexer" />
            </Match>
            <Sort>
                <Access Order="public internal protected-internal protected private" />
                <Static />
                <Abstract />
                <Virtual />
                <Override />
                <Name />
            </Sort>
            <Group Region="Indexers" />
        </Entry>
        <!--  Methods  -->
        <Entry>
            <Match>
                <And>
                    <Or>
                        <Kind Is="method" />
                        <Kind Is="operator" />
                        <HandlesEvent />
                    </Or>
                    <Not>
                        <Kind Is="destructor" />
                    </Not>
                </And>
            </Match>
            <Sort>
                <Access Order="public internal protected-internal protected private" />
                <Static />
                <Abstract />
                <Virtual />
                <Override />
                <Name />
            </Sort>
            <Group Region="Methods" />
        </Entry>
        <!--  all other members  -->
        <Entry />
        <!--  nested types  -->
        <Entry>
            <Match>
                <Kind Is="type" />
            </Match>
            <Sort>
                <Access Order="public internal protected-internal protected private" />
                <Static />
                <Abstract />
                <Virtual />
                <Override />
                <Name />
            </Sort>
            <Group Region="Nested Types" />
        </Entry>
    </Pattern>
